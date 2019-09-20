// Api
import { login } from "src/apis";

// Redux Resources
import { createResourceActions } from "src/redux_resources";

// Actions
import { FlashMessage } from "src/utils/flash_message";

const resourceActions = createResourceActions("login");

/**
 * Action creator for login
 */
export function loginAction(payload) {
  return dispatch => {
    dispatch(resourceActions.loadingPostAction());
    return login(payload)
      .then(response => {
        const login = response.data;
        dispatch(
          resourceActions.populatePostAction({
            data: login
          })
        );
        FlashMessage("success", "Login successfully");
        // dispatch(create("Login successfully", "success"));
      })
      .catch(() => {
        // dispatch(create("Sorry, there was an error login", "error"));
        FlashMessage("error", "Login Failed. Please check UserId/Password");

        dispatch(resourceActions.loadErrorPostAction());
      });
  };
}
