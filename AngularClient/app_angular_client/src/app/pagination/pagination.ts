import { Page } from "./page";
import { PaginationSelector } from "./pagination-selector";

export class Pagination<T>{
  selector: PaginationSelector<T>;
  pageSize: number;
  items: T[];
  hasMore: boolean;
  isLoading: boolean;

  static create<T>(
    selector: PaginationSelector<T>,
    pageSize: number = 20,
    items: T[] = [],
  ): Pagination<T>{
    return new Pagination<T>(
      selector,
      pageSize,
      items,
      true,
      false
    );
  }

  private constructor(
    selector: PaginationSelector<T>,
    pageSize: number,
    items: T[],
    hasMore: boolean,
    isLoading: boolean
  ) {
    this.selector = selector;
    this.pageSize = pageSize;
    this.items = items;
    this.hasMore = hasMore;
    this.isLoading = isLoading;
  }

  getNextPage() : Page {
    return new Page(
      this.pageSize,
      this.selector(this.items[this.items.length - 1])
    )
  }

  markAsLoading() : Pagination<T> {
    return new Pagination<T>(
      this.selector,
      this.pageSize,
      this.items,
      this.hasMore,
      true
    )
  }

  markAsLoaded() : Pagination<T> {
    return new Pagination<T>(
      this.selector,
      this.pageSize,
      this.items,
      this.hasMore,
      false
    )
  }

  appendPage(items: T[]) : Pagination<T>{
    return new Pagination<T>(
      this.selector,
      this.pageSize,
      [...this.items, ...items],
      items.length >= this.pageSize,
      false
    )
  }

  refresh(items: T[]) : Pagination<T>{
    return new Pagination<T>(
      this.selector,
      this.pageSize,
      [...items],
      items.length >= this.pageSize,
      false
    )
  }
}
