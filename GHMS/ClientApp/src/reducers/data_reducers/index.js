import { combineReducers } from "redux";
import { coursesResourceReducer } from "src/reducers/data_reducers/courses_reducer";
import { mastertablesResourceReducer } from "src/reducers/data_reducers/mastertables_reducer";
export const dataReducers = combineReducers({
  courses: coursesResourceReducer,
  mastertables: mastertablesResourceReducer
});
