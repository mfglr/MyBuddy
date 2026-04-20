import { PaginatinKey } from "./pagination-key";

export class Page{
  cursor: Array<PaginatinKey<any>>;
  pageSize: number;

  constructor(pageSize: number, cursor: Array<PaginatinKey<any>>) {
    this.pageSize = pageSize;
    this.cursor = cursor;
  }
}
