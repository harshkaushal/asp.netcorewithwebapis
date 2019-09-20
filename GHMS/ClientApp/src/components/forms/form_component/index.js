import React from "react";
import PropTypes from "prop-types";
import { reduxForm } from "redux-form";

const form = "";
/**
 * Form Component that will surround its children
 * form: is used to map the form property of the reduxForm
 * handleSubmit: will be the event that we have passed in the props
 * which will automatically mapped with redux handleSubmit event, We need to
 * send the onSubmit function in the props so that redux form map this accordingly.
 */

const WrapperFormComponent = props => {
  const { form = form, handleSubmit } = props;
  return (
    <form className="padding20px" onSubmit={handleSubmit}>
      {props.children}
    </form>
  );
};

export const FormComponent = reduxForm({
  form: form,
  enableReinitialize: true
})(WrapperFormComponent);
FormComponent.propTypes = {
  onSubmit: PropTypes.func.isRequired
};
