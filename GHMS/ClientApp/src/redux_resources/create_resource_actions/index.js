import { createActionTypesForResourceName } from "../create_action_types_for_resource_name";

/**
 * Create a set of actions for a json api resource reducer
 * @param {string} name the resource name
 * @returns {Object} actions object
 */
export function createResourceActions(name) {
  const actionTypes = createActionTypesForResourceName(name);

  return {
    /**
     * Append objects to store and replace meta data
     * @param {array|string} contexts array of context strings or context string
     * @param {object} data
     * @param {array} ids
     * @param {object} links
     * @param {object} meta
     */
    replaceAction: ({ contexts, data, ids, links, meta }) => {
      if (typeof contexts == "string") {
        contexts = [contexts];
      }

      return {
        type: actionTypes.replace,
        payload: {
          contexts,
          data,
          ids,
          links,
          meta
        }
      };
    },

    /**
     * Append objects to store and replace meta data
     * @param {array|string} contexts array of context strings or context string
     * @param {object} data
     * @param {array} ids
     * @param {object} links
     * @param {object} meta
     */
    populateAction: ({ contexts, data, ids, links, meta }) => {
      if (typeof contexts == "string") {
        contexts = [contexts];
      }
      return {
        type: actionTypes.populate,
        payload: {
          contexts,
          data,
          ids,
          links,
          meta
        }
      };
    },

    populatePatchAction: ({ data, ids }) => {
      return {
        type: actionTypes.populatePatch,
        payload: {
          data,
          ids
        }
      };
    },

    populatePostAction: ({ data }) => {
      return {
        type: actionTypes.populatePost,
        payload: {
          data
        }
      };
    },

    /**
     * @param {string} context
     * @param {string} loadState
     * @returns {Object} redux action
     */
    setLoadStateForContextAction: (context, loadState) => {
      return {
        type: actionTypes.setLoadStateForContext,
        payload: {
          context,
          loadState
        }
      };
    },

    /**
     * @deprecated
     * Set loading state for context
     * @param {array|string} contexts
     */
    loadingForContextAction: contexts => {
      if (typeof contexts == "string") {
        contexts = [contexts];
      }
      return {
        type: actionTypes.loadingForContext,
        payload: {
          contexts
        }
      };
    },

    /**
     * @deprecated
     */
    loadingMoreForContextAction: contexts => {
      if (typeof contexts == "string") {
        contexts = [contexts];
      }
      return {
        type: actionTypes.loadingMoreForContext,
        payload: {
          contexts
        }
      };
    },

    /**
     * @deprecated
     */
    loadErrorForContextAction: contexts => {
      if (typeof contexts == "string") {
        contexts = [contexts];
      }
      return {
        type: actionTypes.loadErrorForContext,
        payload: {
          contexts
        }
      };
    },

    loadingPostAction: () => {
      return {
        type: actionTypes.loadingPost
      };
    },

    loadErrorPostAction: () => {
      return {
        type: actionTypes.loadErrorPost
      };
    },

    loadingPatchAction: ids => {
      return {
        type: actionTypes.loadingPatch,
        payload: {
          ids
        }
      };
    },

    loadErrorPatchAction: ids => {
      return {
        type: actionTypes.loadErrorPatch,
        payload: {
          ids
        }
      };
    },

    /**
     * Action creator to increment the current page for a context
     * @param {string} context
     * @returns {Object} redux action
     */
    incrementPageForContextAction: context => {
      return {
        type: actionTypes.incrementPageForContext,
        payload: {
          context
        }
      };
    }
  };
}
