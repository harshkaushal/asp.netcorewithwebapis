/**
 * Create action types for a resource name
 * @param {string} name the resource name (ex. series)
 */
export function createActionTypesForResourceName(name) {
  const uppercaseName = name.toUpperCase();

  return {
    replace: `${uppercaseName}_RESOURCE_REPLACE`,
    populate: `${uppercaseName}_RESOURCE_POPULATE`,
    populatePatch: `${uppercaseName}_RESOURCE_POPULATE_PATCH`,
    populatePost: `${uppercaseName}_RESOURCE_POPULATE_POST`,
    setLoadStateForContext: `${uppercaseName}_RESOURCE_SET_LOAD_STATE_FOR_CONTEXT`,
    loadingForContext: `${uppercaseName}_RESOURCE_LOADING_FOR_CONTEXT`,
    loadingMoreForContext: `${uppercaseName}_RESOURCE_LOADING_MORE_FOR_CONTEXT`,
    loadErrorForContext: `${uppercaseName}_RESOURCE_LOAD_ERROR_FOR_CONTEXT`,
    loadingPost: `${uppercaseName}_RESOURCE_LOADING_POST_INDEX`,
    loadErrorPost: `${uppercaseName}_RESOURCE_LOAD_ERROR_POST_INDEX`,
    loadingPatch: `${uppercaseName}_RESOURCE_LOADING_PATCH`,
    loadErrorPatch: `${uppercaseName}_RESOURCE_LOAD_ERROR_PATCH_INDEX`,
    incrementPageForContext: `${uppercaseName}_RESOURCE_INCREMENT_PAGE_FOR_CONTEXT`
  };
}
