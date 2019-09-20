import axios from "axios";
//import qs from "qs";
import { responseErrorInterceptor } from "../interceptors";
import { apiUrl } from "src/constants";
const axiosInstance = axios.create({
  baseURL: apiUrl
});

axiosInstance.interceptors.response.use(undefined, responseErrorInterceptor);

/**
 * Fetch courses data
 * @return {Promise} Promise with the response
 */
export function fetchCourses() {
  const url = "/GetAspNetRoles";
  return axiosInstance.get(url);
  //   return new Promise(resolve => {
  //     setTimeout(() => {
  //       resolve(Object.assign([], courses));
  //     }, delay);
  //   });
}
