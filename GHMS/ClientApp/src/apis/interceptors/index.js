import store from "src/store/configureStore";

import { push } from "react-router-redux";

/**
 * Interceptor for api response errors
 * handles redirect to login when token is expired
 */
export function responseErrorInterceptor(error) {
  const response = error.response;

  if (response && response.status == 401) {
    // session expired message
    // store.dispatch(
    //   create("Your session has expired. Please sign in again.", "error")
    // );

    // go to login view
    // TODO: store current state to redirect user back to the same view
    // after they log back in.
    store.dispatch(push("/sign_in"));
    return Promise.reject(error);
  } else {
    return Promise.reject(error);
  }
}
