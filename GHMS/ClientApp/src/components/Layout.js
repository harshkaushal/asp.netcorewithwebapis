import React from "react";
import { Container } from "reactstrap";
import NavMenu from "./NavMenu";
import { NotificationComponent } from "src/components/notification_component";

export default props => (
  <div>
    <NavMenu />
    <NotificationComponent />
    <Container>{props.children}</Container>
  </div>
);
