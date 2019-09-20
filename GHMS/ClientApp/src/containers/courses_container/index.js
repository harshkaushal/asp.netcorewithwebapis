import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { withCoursesLoader } from "src/hoc";
import flowRight from "lodash.flowright";

// Components
import { CoursesComponent } from "src/components/courses_component";
import { loadCoursesAction, loginAction } from "src/actions/data_actions";
// Selectors
import { coursesResourceSelectors } from "src/selectors/data_selectors";
import { notificationSectionSelector } from "src/selectors/notifications";

function mapDispatchToProps(dispatch) {
  return {
    loadCoursesData(url, payload) {
      return loadCoursesAction(url, payload);
    },
    loginUser(payload) {
      return dispatch(loginAction(payload));
    }
  };
}
function mapStateToProps(state) {
  return {
    coursesLoadState: coursesResourceSelectors.createContextLoadStateSelectorWithContextString(
      "courses"
    )(state),
    courses: coursesResourceSelectors.dataSelector(state),
    notification: notificationSectionSelector(state)
  };
}

export const CoursesContainer = flowRight(
  withRouter,
  withCoursesLoader,
  component => {
    return {
      WrappedComponent: component,
      context: "courses"
    };
  },
  connect(
    mapStateToProps,
    mapDispatchToProps
  )
)(CoursesComponent);
