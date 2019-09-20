import { createSelector } from "reselect";
import { dataSelector as outerDataSelector } from "src/selectors/data_selectors/data_selector";
import { isObject } from "src/utils/is_object";

/**
 * Create set of basic selectors for a jsonapi resource
 * @param {string} storeName the resource/store name
 * @returns {Object} object with selectors
 */
export function createResourceSelectors(storeName) {
  const sectionSelector = createSelector(
    outerDataSelector,
    data => data[storeName]
  );

  // LOAD STATE SELECTORS

  /**
   * selector for the load state
   */
  const loadStateSelector = createSelector(
    sectionSelector,
    section => section.loadState
  );

  /**
   * Selector for the 'contextLoadState'
   */
  const contextLoadStateSelector = createSelector(
    loadStateSelector,
    loadState => loadState.contextLoadState
  );

  /**
   * Selector for the 'patch' load state
   */
  const patchLoadStateSelector = createSelector(
    loadStateSelector,
    loadState => loadState.patch
  );

  /**
   * Selector for the 'post' load state
   */
  const postLoadStateSelector = createSelector(
    loadStateSelector,
    loadState => loadState.post
  );

  /**
   * @deprecated
   * create a selector for load state for a context using a context string
   * @param {string} context the context string
   * @returns {Function} selector
   */
  const createContextLoadStateSelectorWithContextString = context => {
    return createSelector(
      contextLoadStateSelector,
      contextLoadState => contextLoadState[context]
    );
  };

  /**
   * @deprecated
   * create a selector for load state for a context using a context string selector
   * @param {Function} selector selector for the context string
   * @returns {Function} selector
   */
  const createContextLoadStateSelectorWithContextStringSelector = selector => {
    return createSelector(
      selector,
      contextLoadStateSelector,
      (context, contextLoadState) => {
        return contextLoadState[context];
      }
    );
  };

  /**
   * Get the load state for a context string or context string selector
   * @param {string|Function} context - context string or selector for a context string
   */
  const createLoadStateForContextSelector = context => {
    if (typeof context == "function") {
      // Handle case for context being a selector
      return createSelector(
        context,
        contextLoadStateSelector,
        (context, contextLoadState) => {
          return contextLoadState[context];
        }
      );
    } else {
      return createSelector(
        contextLoadStateSelector,
        contextLoadState => contextLoadState[context]
      );
    }
  };

  // META SELECTORS

  /**
   * Selector for the 'meta' object
   */
  const metaSelector = createSelector(
    sectionSelector,
    section => section.meta
  );

  /**
   * @deprecated
   * Create a selector for meta for a specific context
   * @param {string} context - the context string
   * @returns {Function} selector
   */
  const createMetaContextSelectorWithString = context => {
    return createSelector(
      metaSelector,
      meta => meta[context]
    );
  };

  /**
   * @deprecated
   * Create a selector for meta for a specific context using context string selector
   * @param {Function} contextStringSelector - the selector for context string
   * @returns {Function} selector
   */
  const createMetaContextSelectorWithSelector = contextStringSelector => {
    return createSelector(
      metaSelector,
      contextStringSelector,
      (meta, context) => meta[context]
    );
  };

  /**
   * Create meta selector for context.
   * Supports array, string, or selector arguments.
   * @param {string|array|Function} context - context string or selector to get contexts/context string
   */
  const createMetaForContextSelector = context => {
    if (typeof context == "function") {
      // Handle case for context being a selector
      return createSelector(
        metaSelector,
        context,
        (meta, contextValue) => {
          if (Array.isArray(contextValue)) {
            return contextValue.map(cv => {
              return meta[cv];
            });
          } else if (isObject(contextValue)) {
            return Object.keys(contextValue).reduce((agg, key) => {
              agg[key] = meta[contextValue[key]];
              return agg;
            }, {});
          }
          return meta[contextValue];
        }
      );
    } else {
      // Handle case for context being a string or array
      return createSelector(
        metaSelector,
        meta => {
          if (Array.isArray(context)) {
            return context.map(cv => {
              return meta[cv];
            });
          }
          return meta[context];
        }
      );
    }
  };

  /**
   * Get the page count for a context and page limit.
   * Supports literal values and selectors for both arguments.
   * @param {string|Function} context
   * @param {number|Function} pageLimit
   */
  const createPageCountSelector = (context, pageLimit) => {
    if (typeof context == "function") {
      if (typeof pageLimit == "function") {
        return createSelector(
          createMetaForContextSelector(context),
          pageLimit,
          (meta, limitValue) => {
            if (!meta || !meta.meta || !meta.meta.recordCount) {
              return undefined;
            }

            return Math.ceil(meta.meta.recordCount / limitValue);
          }
        );
      } else {
        return createSelector(
          createMetaForContextSelector(context),
          meta => {
            if (!meta || !meta.meta || !meta.meta.recordCount) {
              return undefined;
            }

            return Math.ceil(meta.meta.recordCount / pageLimit);
          }
        );
      }
    } else {
      return createSelector(
        createMetaForContextSelector(context),
        pageLimit,
        (meta, pageLimit) => {
          if (!meta || !meta.meta || !meta.meta.recordCount) {
            return undefined;
          }
          return Math.ceil(meta.meta.recordCount / pageLimit);
        }
      );
    }
  };

  /**
   * Get the record count for a context
   * Supports literal values and selectors for both arguments.
   * @param {string|Function} context
   */
  const createRecordCountSelector = context => {
    if (typeof context == "function") {
      return createSelector(
        createMetaForContextSelector(context),
        meta => {
          if (Array.isArray(meta)) {
            throw "Context selectors that return arrays not support for createRecordCountSelector yet";
          } else if (meta && !meta.meta && isObject(meta)) {
            return Object.keys(meta).reduce((agg, key) => {
              const value = meta[key];
              if (!value || !value.meta || !value.meta.recordCount) {
                return agg;
              }

              agg[key] = meta[key].meta.recordCount;
              return agg;
            }, {});
          } else if (!meta || !meta.meta || !meta.meta.recordCount) {
            return undefined;
          }
          return meta.meta.recordCount;
        }
      );
    } else {
      return createSelector(
        createMetaForContextSelector(context),
        meta => {
          if (!meta || !meta.meta || !meta.meta.recordCount) {
            return undefined;
          }

          return meta.meta.recordCount;
        }
      );
    }
  };

  // DATA SELECTORS

  /**
   * Selector for the data object
   */
  const dataSelector = createSelector(
    sectionSelector,
    section => section.data
  );

  /**
   * @deprecated
   * Create a selector for data for a specific context
   * @param {string} context - the context string
   * @returns {Function} selector
   */
  const createDataForContextSelectorWithString = context => {
    return createSelector(
      dataSelector,
      createMetaContextSelectorWithString(context),
      (data, meta) => {
        if (meta && meta.ids) {
          return meta.ids.map(id => {
            return data[id];
          });
        } else {
          return [];
        }
      }
    );
  };

  /**
   * @deprecated
   * Create a selector for data for a specific context using a context string selector
   * @param {Function} contextSelector - the context string selector
   * @returns {Function} selector
   */
  const createDataForContextSelectorWithSelector = contextSelector => {
    return createSelector(
      dataSelector,
      createMetaContextSelectorWithSelector(contextSelector),
      (data, meta) => {
        if (meta && meta.ids) {
          return meta.ids.map(id => {
            return data[id];
          });
        } else {
          return [];
        }
      }
    );
  };

  /**
   * Create data selector for context.
   * Supports context string, array of contexts, selector that returns context/contexts
   * @param {string|array|Function} context
   */
  const createDataForContextSelector = context => {
    return createSelector(
      dataSelector,
      createMetaForContextSelector(context),
      (data, meta) => {
        if (Array.isArray(meta)) {
          return meta.reduce((agg, m) => {
            if (m && m.ids) {
              const dataForMeta = m.ids.map(id => data[id]);
              agg = agg.concat(dataForMeta);
            }
            return agg;
          }, []);
        } else if (meta && meta.ids) {
          return meta.ids.map(id => data[id]);
        } else {
          return [];
        }
      }
    );
  };

  // CURRENT PAGE SELECTORS

  //   const currentPageByContextSelector = createSelector(
  //     sectionSelector,
  //     section => section.currentPageByContext
  //   );

  /**
   * Create current page for context selector
   * @param {string|Function} context
   */
  const createCurrentPageForContextSelector = () => {
    // if (typeof context == "function") {
    //   // Handle case for context being a selector
    //   return createSelector(
    //     currentPageByContextSelector,
    //     context,
    //     (currentPageByContext, contextValue) => {
    //       return currentPageByContext[contextValue]
    //         ? currentPageByContext[contextValue]
    //         : 0;
    //     }
    //   );
    // } else {
    //   // Handle case for context being a string or array
    //   return createSelector(
    //     currentPageByContextSelector,
    //     currentPageByContext => {
    //       return currentPageByContext[contextValue]
    //         ? currentPageByContext[contextValue]
    //         : 0;
    //     }
    //   );
    // }
  };

  return {
    // LOAD STATE
    contextLoadStateSelector,
    createLoadStateForContextSelector,
    patchLoadStateSelector,
    postLoadStateSelector,

    // deprecated
    createContextLoadStateSelectorWithContextString,
    // deprecated
    createContextLoadStateSelectorWithContextStringSelector,

    // META
    metaSelector,
    createMetaForContextSelector,
    createPageCountSelector,
    createRecordCountSelector,

    // deprecated
    createMetaContextSelectorWithString,
    // deprecated
    createMetaContextSelectorWithSelector,

    // DATA
    dataSelector,
    createDataForContextSelector,

    // deprecated
    createDataForContextSelectorWithString,
    // deprecated
    createDataForContextSelectorWithSelector,

    // PAGE
    createCurrentPageForContextSelector
  };
}
