import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { withRoutesLoader } from "src/hoc";
import flowRight from "lodash.flowright";

// Components
import { RoutesComponent } from "src/components/routes_component";

// Selectors
import { mastertablesResourceSelectors } from "src/selectors/data_selectors";

function mapDispatchToProps() {
  return {};
}
function mapStateToProps(state) {
  return {
    routesLoadState: mastertablesResourceSelectors.createContextLoadStateSelectorWithContextString(
      "mastertables"
    )(state),
    routes: mastertablesResourceSelectors.dataSelector(state)
  };
}

export const RoutesContainer = flowRight(
  withRoutesLoader,
  component => {
    return {
      WrappedComponent: component,
      context: "mastertables"
    };
  },
  connect(
    mapStateToProps,
    mapDispatchToProps
  )
)(RoutesComponent);
