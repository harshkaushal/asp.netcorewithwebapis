import { createSelector } from "reselect";

const getData = state => state.data;

/**
 * Selector to get the data state tree
 */
export const dataSelector = createSelector(
  getData,
  data => {
    return data;
  }
);
