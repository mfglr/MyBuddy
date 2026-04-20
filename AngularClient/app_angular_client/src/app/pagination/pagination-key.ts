export class PaginatinKey<T>{
  isDescending: boolean;
  key?: T;

  constructor(isDescending: boolean, key?: T) {
    this.isDescending = isDescending;
    this.key = key;
  }
}
