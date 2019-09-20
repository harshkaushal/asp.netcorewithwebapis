import { combineReducers } from "redux";
import { dataReducers } from "./data_reducers";

const mainReducer = combineReducers({
  data: dataReducers
});

export default mainReducer;
