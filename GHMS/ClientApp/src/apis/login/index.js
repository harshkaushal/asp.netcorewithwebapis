import axios from "axios";
import { responseErrorInterceptor } from "../interceptors";
import { apiUrl } from "src/constants";
const axiosInstance = axios.create({
  baseURL: apiUrl
});

axiosInstance.interceptors.response.use(undefined, responseErrorInterceptor);

/**
 * login for users
 * @param {Object} payload - responsible for sending the data to api.
 * @return {Promise} Promise with the response
 */
export function login(payload) {
  const url = "/Login";
  return axiosInstance.post(url, payload);
}
