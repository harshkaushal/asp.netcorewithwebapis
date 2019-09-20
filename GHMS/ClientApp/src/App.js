import React from "react";
import { Route, Switch } from "react-router";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Counter from "./components/Counter";
import FetchData from "./components/FetchData";

import { CoursesContainer } from "./containers/courses_container";
import { RoutesContainer } from "./containers/routes_container";

export default () => {
  return (
    <Layout>
      <Switch>
        <Route exact key="home" path="/" component={Home} />
        <Route key="counter" path="/counter" component={Counter} />
        <Route
          key="fetch-data"
          path="/fetch-data/:startDateIndex?"
          component={FetchData}
        />
        <Route key="courses" path="/courses" component={CoursesContainer} />
        <RoutesContainer />
      </Switch>
    </Layout>
  );
};
