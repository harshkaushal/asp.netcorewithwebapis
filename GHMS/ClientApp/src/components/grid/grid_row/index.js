import React, { PureComponent } from "react";
import PropTypes from "prop-types";
import classnames from "classnames";

export class GridRow extends PureComponent {
  static propTypes = {
    className: PropTypes.string
  };

  render() {
    const { children, className } = this.props;
    const klass = classnames("row", className);
    return <div className={klass}>{children}</div>;
  }
}
