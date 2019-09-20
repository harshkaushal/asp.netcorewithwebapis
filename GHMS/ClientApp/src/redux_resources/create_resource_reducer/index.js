import { loadStates } from "src/constants/load_states";
import { createActionTypesForResourceName } from "../create_action_types_for_resource_name";
import uniq from "lodash.uniq";

/**
 * Create a redux reducer for a json api resource
 * @param {string} name the resource name
 * @returns {Function} redux reducer
 */
export function createResourceReducer(name) {
  const actionTypes = createActionTypesForResourceName(name);

  const defaultState = {
    // Keep track of load state
    loadState: {
      // id, filter or a constant
      contextLoadState: {},

      // id keys
      patch: {},

      // single state for posts (only support posting 1 thing at a time for now)
      post: loadStates.ready
    },

    // Holds the denormalized data (id keys)
    data: {},

    // Meta object broken down by context
    // context:
    // - ids
    // - links
    // - meta
    meta: {},

    // keep track of the current page for a context
    currentPageByContext: {}
  };

  return (state = defaultState, action) => {
    let loadState;
    let meta;
    let contexts;
    let ids;
    let links;

    switch (action.type) {
      // Replace:
      // append data to the store
      // set load state for the context
      // replace meta content for the context (ids not merged)
      case actionTypes.replace:
        meta = { ...state.meta };
        loadState = { ...state.loadState };

        contexts =
          typeof action.payload.contexts == "string"
            ? [action.payload.contexts]
            : action.payload.contexts;
        ids = action.payload.ids;
        links = action.payload.links;

        // if context is provided add meta data and set load state
        contexts.forEach(context => {
          meta[context] = {
            ids,
            links,
            meta: action.payload.meta
          };

          loadState.contextLoadState[context] = loadStates.loaded;
        });

        return {
          ...state,
          loadState,
          data: { ...state.data, ...action.payload.data },
          meta
        };

      // Populate:
      // append data to the store
      // set load state for the context
      // append meta.ids and replace other meta info
      case actionTypes.populate:
        meta = { ...state.meta };
        loadState = { ...state.loadState };
        contexts =
          typeof action.payload.contexts == "string"
            ? [action.payload.contexts]
            : action.payload.contexts;
        ids = action.payload.ids;
        links = action.payload.links;

        if (contexts) {
          contexts.forEach(context => {
            // merge ids
            let metaIds = ids;
            if (meta[context]) {
              metaIds = metaIds
                ? [...meta[context].ids, ...ids]
                : meta[context].ids;
              metaIds = uniq(metaIds);
            }

            meta[context] = {
              ids: metaIds,
              links,
              meta: action.payload.meta
            };

            loadState.contextLoadState[context] = loadStates.loaded;
          });
        }

        return {
          ...state,
          loadState,
          data: { ...state.data, ...action.payload.data },
          meta
        };

      // Populate patch:
      // append data to the store
      // update patch load state to loaded
      case actionTypes.populatePatch:
        loadState = { ...state.loadState };
        if (action.payload.ids) {
          loadState.patch = {
            ...loadState.patch,
            ...action.payload.ids.reduce((agg, id) => {
              agg[id] == loadStates.loaded;
              return agg;
            }, {})
          };
        }

        return {
          ...state,
          data: { ...state.data, ...action.payload.data },
          loadState
        };

      // Populate post:
      // append data to the store
      // update post load state
      case actionTypes.populatePost:
        return {
          ...state,
          data: { ...state.data, ...action.payload.data },
          loadState: { ...state.loadState, post: loadStates.ready }
        };

      case actionTypes.setLoadStateForContext:
        loadState = { ...state.loadState };
        loadState.contextLoadState[action.payload.context] =
          action.payload.loadState;
        return {
          ...state,
          loadState
        };

      // Loading by context:
      // sets the loadState.contextLoadState[action.payload.context] to loading
      case actionTypes.loadingForContext:
        loadState = { ...state.loadState };
        action.payload.contexts.forEach(context => {
          loadState.contextLoadState[context] = loadStates.loading;
        });
        return {
          ...state,
          loadState
        };

      // Loading by context:
      // sets the loadState.contextLoadState[action.payload.context] to loadMore
      case actionTypes.loadingMoreForContext:
        loadState = { ...state.loadState };
        action.payload.contexts.forEach(context => {
          loadState.contextLoadState[context] = loadStates.loadingMore;
        });
        return {
          ...state,
          loadState
        };

      // Loading by context:
      // sets the loadState.contextLoadState[action.payload.context] to error
      case actionTypes.loadErrorForContext:
        loadState = { ...state.loadState };
        action.payload.contexts.forEach(context => {
          loadState.contextLoadState[context] = loadStates.error;
        });
        return {
          ...state,
          loadState
        };

      // Loading post
      // set loadState.post to loading
      case actionTypes.loadingPost:
        return {
          ...state,
          loadState: {
            ...state.loadState,
            post: loadStates.loading
          }
        };

      // Load error post
      // set loadState.post to error
      case actionTypes.loadErrorPost:
        return {
          ...state,
          loadState: {
            ...state.loadState,
            post: loadStates.error
          }
        };

      // Patch loading:
      // sets loadState.patch for each id provided
      case actionTypes.loadingPatch:
        loadState = { ...state.loadState };
        if (action.payload.ids) {
          loadState.patch = {
            ...loadState.patch,
            ...action.payload.ids.reduce((agg, id) => {
              agg[id] == loadStates.loading;
              return agg;
            }, {})
          };
        }

        return {
          ...state,
          loadState
        };

      // Patch load error:
      // sets loadState.patch for each id provided
      case actionTypes.loadErrorPatch:
        loadState = { ...state.loadState };
        if (action.payload.ids) {
          loadState.patch = {
            ...loadState.patch,
            ...action.payload.ids.reduce((agg, id) => {
              agg[id] == loadStates.error;
              return agg;
            }, {})
          };
        }

        return {
          ...state,
          loadState
        };

      case actionTypes.incrementPageForContext:
        const context = action.payload.context;
        const currentPage = state.currentPageByContext[context];
        const newPage = currentPage ? currentPage + 1 : 1;

        return {
          ...state,
          currentPageByContext: {
            ...state.currentPageByContext,
            [context]: newPage
          }
        };

      default:
        return state;
    }
  };
}
