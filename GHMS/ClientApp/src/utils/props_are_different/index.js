import isEqual from "lodash.isequal";
import get from "lodash.get";
import moment from "moment";

/**
 * Helper function that will compare two sets of props for equality
 * @param {Object} newProps the new props
 * @param {Object} oldProps the old props
 * @param {Array} propNames name of the props to compare
 *
 * @return {boolean} true if props are not equal
 */
export function propsAreDifferent(newProps, oldProps, ...propNames) {
  for (let i = 0; i < propNames.length; i++) {
    // Get the props
    const propName = propNames[i];
    const oldProp = get(oldProps, propName);
    const newProp = get(newProps, propName);

    // Compare props
    if (moment.isMoment(oldProp) || moment.isMoment(newProp)) {
      if (!oldProp.isSame(newProp)) {
        return true;
      }
    } else {
      if (!isEqual(newProp, oldProp)) {
        return true;
      }
    }
  }

  return false;
}
