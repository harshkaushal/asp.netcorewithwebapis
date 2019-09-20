import { NotificationManager } from "react-notifications";

export function FlashMessage(type, message, title, timeout) {
  timeout = timeout ? timeout : 3000;
  switch (type) {
    case "info":
      NotificationManager.info(message);
      break;
    case "success":
      NotificationManager.success(message, title);
      break;
    case "warning":
      NotificationManager.warning(message, title);
      break;
    case "error":
      NotificationManager.error(message, title, timeout);
      break;
  }
}
