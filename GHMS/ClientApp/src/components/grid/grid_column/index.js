import React, { PureComponent } from "react";
import PropTypes from "prop-types";
import classnames from "classnames";

export class GridColumn extends PureComponent {
  props: $props;
  static propTypes = {
    className: PropTypes.string,
    xs: PropTypes.string,
    sm: PropTypes.string,
    md: PropTypes.string,
    lg: PropTypes.string,
    xl: PropTypes.string
  };

  render() {
    const { children, className, sm, md, lg, xl, xs } = this.props;

    const klass = classnames(className, {
      [`col-xs-${xs || ""}`]: xs,
      [`col-sm-${sm || ""}`]: sm,
      [`col-md-${md || ""}`]: md,
      [`col-lg-${lg || ""}`]: lg,
      [`col-xl-${xl || ""}`]: xl
    });

    return <div className={klass}>{children}</div>;
  }
}
