import React from "react";
//import PropTypes from "prop-types";
import { connect } from "react-redux";

// Selectors
import { mastertablesResourceSelectors } from "src/selectors/data_selectors";

// Actions
import { loadMasterTablesAction } from "src/actions/data_actions/mastertables";

/**
 * HOC that is responsible for loading a list of routes
 * @param {Class} WrappedComponent the component dependent on this data
 * @return {Class} Component wrapped by the loader component
 */
export function withRoutesLoader({ WrappedComponent, context }) {
  class RoutesLoader extends React.Component {
    componentWillMount() {
      if (!Object.keys(this.props.routes).length) {
        this.props.sendLoadRoutesAction(context);
      }
    }

    render() {
      return <WrappedComponent />;
    }
  }

  return connect(
    mapStateToProps,
    mapDispatchToProps
  )(RoutesLoader);

  /**
   * Map the props needed for loading data
   */
  function mapStateToProps(state) {
    return {
      routesLoadState: mastertablesResourceSelectors.createContextLoadStateSelectorWithContextString(
        context
      )(state),
      routes: mastertablesResourceSelectors.dataSelector(state)
    };
  }

  /**
   * Map dispatch to a props for loading data
   */
  function mapDispatchToProps(dispatch) {
    return {
      sendLoadRoutesAction(context) {
        dispatch(loadMasterTablesAction(context));
      }
    };
  }
}
