import axios from "axios";
import { responseErrorInterceptor } from "../interceptors";
import { apiUrl } from "src/constants";
const axiosInstance = axios.create({
  baseURL: apiUrl
});

axiosInstance.interceptors.response.use(undefined, responseErrorInterceptor);

/**
 * Fetch master tables name data
 * @return {Promise} Promise with the response
 */
export function fetchMasterTablesName() {
  const url = "/GetAllLookUpTables";
  return axiosInstance.get(url);
}
