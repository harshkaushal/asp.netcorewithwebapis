/**
 * check if a value is an object
 * @param {Object} param
 */
export function isObject(param) {
  if (Array.isArray(param)) {
    return false;
  } else {
    return param === Object(param);
  }
}
