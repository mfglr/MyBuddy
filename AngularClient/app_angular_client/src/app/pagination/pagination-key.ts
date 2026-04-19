export class PaginatinKey<T>{
  property: T;
  isDescending: boolean;

  constructor(property: T, isDescending: boolean) {
    this.property = property;
    this.isDescending = isDescending;
  }
}
