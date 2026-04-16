export class PostMediaRequiredError extends Error {
  constructor() {
    super("A post must have at least one media item.");
  }
}
