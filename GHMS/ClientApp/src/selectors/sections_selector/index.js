import { createSelector } from "reselect";

const getSections = state => {
  return state;
};

/**
 * Memoized selector for the sections state tree
 * this part of the state hosts user selections and filters
 */
export const sectionsSelector = createSelector(
  getSections,
  sections => {
    return sections;
  }
);
