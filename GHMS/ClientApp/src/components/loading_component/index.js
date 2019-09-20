import React from "react";

/**
 * Component used to display a loading state
 */
export class LoadingComponent extends React.PureComponent {
  render() {
    return (
      <div className="loader-demo d-flex align-items-center justify-content-center">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div className="spinner-border" role="status">
          <span className="sr-only">Loading...</span>
        </div>
      </div>
    );
  }
}
