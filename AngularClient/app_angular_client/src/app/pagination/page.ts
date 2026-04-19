import { PaginatinKey } from "./pagination-key";

export class Page{
  cursor: Array<PaginatinKey<any>> | null;
  pageSize: number;

  constructor(pageSize: number, cursor: Array<PaginatinKey<any>> | null = null) {
    this.pageSize = pageSize;
    this.cursor = cursor;
  }
}
