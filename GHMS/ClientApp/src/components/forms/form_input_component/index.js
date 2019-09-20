import React from "react";
import PropTypes from "prop-types";
import { Field } from "redux-form";

const renderField = ({
  input,
  placeholder,
  type,
  className,
  children,
  disabled,
  meta: { touched, error, warning }
}) => {
  if (type == "select") {
    return (
      <div>
        <select {...input} disabled={disabled} className={className}>
          {children}
        </select>
        {touched &&
          ((error && <span className="error">{error}</span>) ||
            (warning && <span>{warning}</span>))}
      </div>
    );
  } else
    return (
      <div>
        <input
          {...input}
          className={className}
          placeholder={placeholder}
          disabled={disabled}
          type={type}
        />
        {touched &&
          ((error && <span className="error">{error}</span>) ||
            (warning && <span>{warning}</span>))}
      </div>
    );
};
export class FormInputComponent extends React.PureComponent {
  static propTypes = {
    component: PropTypes.string.isRequired,
    componentType: PropTypes.string,
    placeholder: PropTypes.string,
    name: PropTypes.string.isRequired,
    labelText: PropTypes.string,
    disabled: PropTypes.bool,
    validate: PropTypes.array,
    normalize: PropTypes.func
  };
  static defaultProps = {
    disabled: false
  };

  render() {
    console.log("Field", Field);

    return (
      <Field
        className="form-control"
        name={this.props.name}
        component={renderField}
        type={this.props.componentType}
        placeholder={this.props.placeholder}
        disabled={this.props.disabled}
        validate={this.props.validate}
        normalize={this.props.normalize}
      >
        {this.props.children}
      </Field>
    );
  }
}
