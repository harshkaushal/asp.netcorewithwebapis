import React from "react";
//import PropTypes from "prop-types";
import { connect } from "react-redux";

// Selectors
import { coursesResourceSelectors } from "src/selectors/data_selectors";

// Actions
import { loadCoursesAction } from "src/actions/data_actions/courses";

/**
 * HOC that is responsible for loading a list of courses
 * @param {Class} WrappedComponent the component dependent on this data
 * @return {Class} Component wrapped by the loader component
 */
export function withCoursesLoader({ WrappedComponent, context }) {
  class CoursesLoader extends React.Component {
    componentWillMount() {
      // Load courses if we haven't already
      if (!Object.keys(this.props.courses).length) {
        this.props.sendLoadCoursesAction(context);
      }
    }

    render() {
      return <WrappedComponent />;
    }
  }

  return connect(
    mapStateToProps,
    mapDispatchToProps
  )(CoursesLoader);

  /**
   * Map the props needed for loading data
   */
  function mapStateToProps(state) {
    return {
      coursesLoadState: coursesResourceSelectors.createContextLoadStateSelectorWithContextString(
        context
      )(state),
      courses: coursesResourceSelectors.dataSelector(state)
    };
  }

  /**
   * Map dispatch to a props for loading data
   */
  function mapDispatchToProps(dispatch) {
    return {
      sendLoadCoursesAction(context) {
        dispatch(loadCoursesAction(context));
      }
    };
  }
}
