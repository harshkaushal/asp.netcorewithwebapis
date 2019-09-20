import { fetchCourses } from "src/apis/courses";
import { createResourceActions } from "src/redux_resources";

const resourceActions = createResourceActions("courses");

/**
 * Action creator to fetch courses data
 * @param {Object} contexts
 * @return {Object} redux action
 */
export function loadCoursesAction(contexts) {
  return dispatch => {
    dispatch(resourceActions.loadingForContextAction(contexts));
    return fetchCourses()
      .then(response => {
        const courses = response;
        dispatch(
          resourceActions.replaceAction({
            contexts,
            data: courses,
            ids: Object.keys(courses.data),
            links: [],
            meta: []
          })
        );
      })
      .catch(() => {
        dispatch(resourceActions.loadErrorForContextAction(contexts));
      });
  };
}
