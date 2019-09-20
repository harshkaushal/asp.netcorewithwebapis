import React from "react";

import "react-notifications/lib/notifications.css";
import { NotificationContainer } from "react-notifications";

export class NotificationComponent extends React.Component {
  render() {
    const { notification } = this.props;
    console.log("notification", notification);
    return (
      <div>
        <NotificationContainer />
      </div>
    );
  }
}
