import { createSelector } from "reselect";
import { sectionsSelector } from "../../sections_selector";

export const notificationSectionSelector = createSelector(
  sectionsSelector,
  sections => {
    return sections.notifications;
  }
);
