export const notificationOpts = {
  // uid: 'once-please', // you can specify your own uid if required
  title: "Hey, it's good to see you!",
  message: "Now you can see how easy it is to use notifications in React!",
  position: "tr",
  autoDismiss: 0,
  action: {
    label: "Click me!!",
    callback: () => alert("clicked!")
  }
};
