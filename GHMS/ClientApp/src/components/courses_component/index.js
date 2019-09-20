import React from "react";
import { LoadingComponent } from "src/components/loading_component";
import { FormInputComponent } from "src/components/forms/form_input_component";
import { FormComponent } from "src/components/forms/form_component";
import { reduxFormNames } from "src/constants";
import { GridRow, GridColumn } from "src/components/grid";
import "./style.css";

export class CoursesComponent extends React.Component {
  onLoginClick = e => {
    console.log(e);
    let payload = {
      hospitalCode: "Hop415",
      username: e.userName,
      password: e.password
    };
    this.props.loginUser(payload);
  };
  render() {
    if (this.props.coursesLoadState == "loading") {
      return <LoadingComponent />;
    } else {
      return (
        <div>
          <table className="table table-striped">
            <thead>
              <tr>
                <th>Name</th>
                <th>Normalized Name</th>
              </tr>
            </thead>
            <tbody>
              {this.props.courses.data.map(course => (
                <tr key={course.name}>
                  <td>{course.name}</td>
                  <td>{course.normalizedName}</td>
                </tr>
              ))}
            </tbody>
          </table>

          <FormComponent
            form={reduxFormNames.loginForm}
            onSubmit={this.onLoginClick}
          >
            <GridRow className="marginBottom15px">
              <GridColumn sm="2">
                <label>User Name</label>
              </GridColumn>
              <GridColumn sm="10">
                <FormInputComponent
                  name="userName"
                  component="input"
                  componentType="text"
                  placeholder="Username"
                  labelText="User Name"
                  //  validate={[required, validatePassword]}
                />
              </GridColumn>
            </GridRow>
            <GridRow className="marginBottom15px">
              <GridColumn sm="2">
                <label>Password</label>
              </GridColumn>
              <GridColumn sm="10">
                <FormInputComponent
                  name="password"
                  component="input"
                  componentType="password"
                  placeholder="Password"
                  labelText="Password"
                  //  validate={[required, validatePassword]}
                />
              </GridColumn>
            </GridRow>
            <GridRow className="marginBottom15px">
              <GridColumn sm="2" />
              <GridColumn sm="10">
                <button id="btn" type="submit" value="Submit">
                  Submit
                </button>
              </GridColumn>
            </GridRow>
          </FormComponent>
        </div>
      );
    }
  }
}
