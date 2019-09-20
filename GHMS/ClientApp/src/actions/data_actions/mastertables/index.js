import { fetchMasterTablesName } from "src/apis";
import { createResourceActions } from "src/redux_resources";
// Actions
import { FlashMessage } from "src/utils/flash_message";

const resourceActions = createResourceActions("mastertables");

/**
 * Action creator to fetch courses data
 * @param {Object} contexts
 * @return {Object} redux action
 */
export function loadMasterTablesAction(contexts) {
  return dispatch => {
    dispatch(resourceActions.loadingForContextAction(contexts));
    return fetchMasterTablesName()
      .then(response => {
        const masterTbales = response;
        console.log("masterTbales", masterTbales);
        dispatch(
          resourceActions.replaceAction({
            contexts,
            data: masterTbales.data.responseData,
            ids: Object.keys(masterTbales.data.responseData),
            links: [],
            meta: []
          })
        );
      })
      .catch(err => {
        FlashMessage("error", err);

        dispatch(resourceActions.loadErrorForContextAction(contexts));
      });
  };
}
