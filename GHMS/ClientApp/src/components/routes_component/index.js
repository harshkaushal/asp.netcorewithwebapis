import React from "react";
import { Route } from "react-router";
import { LoadingComponent } from "src/components/loading_component";
import "./style.css";
import FetchData from "src/components/FetchData";
import Home from "src/components/Home";
import Counter from "src/components/Counter";

import { CoursesContainer } from "src/containers/courses_container";
export class RoutesComponent extends React.Component {
  render() {
    if (this.props.routesLoadState == "loading") {
      return <LoadingComponent />;
    } else {
      console.log("this.props", this.props);
      const { routes } = this.props;
      return (
        <div>
          {/* <Route exact path="/" component={Home} />
          <Route path="/counter" component={Counter} />
          <Route path="/fetch-data/:startDateIndex?" component={FetchData} />
          <Route path="/courses" component={CoursesContainer} /> */}
          {/* <Route path="/LuContactTypes" component={CoursesContainer} /> */}

          {Object.values(routes).map(o => {
            return (
              <Route
                key={o.tableName}
                path={"/" + o.tableName}
                component={CoursesContainer}
              />
            );
          })}
        </div>
      );
    }
  }
}
