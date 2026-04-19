import { Page } from "./page";
import { PaginationSelector } from "./pagination-selector";

export class Pagination<E>{
  selector: PaginationSelector<E>;
  pageSize: number;
  items: E[];
  hasMore: boolean;
  isLoading: boolean;

  static create<E>(
    selector: PaginationSelector<E>,
    pageSize: number = 20,
    items: E[] = [],
  ): Pagination<E>{
    return new Pagination<E>(
      selector,
      pageSize,
      items,
      true,
      false
    );
  }

  private constructor(
    selector: PaginationSelector<E>,
    pageSize: number,
    items: E[],
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
      this.items.length === 0
        ? null
        : this.selector(this.items[this.items.length - 1])
    )
  }

  markAsLoading() : Pagination<E> {
    return new Pagination<E>(
      this.selector,
      this.pageSize,
      this.items,
      this.hasMore,
      true
    )
  }

  markAsLoaded() : Pagination<E> {
    return new Pagination<E>(
      this.selector,
      this.pageSize,
      this.items,
      this.hasMore,
      false
    )
  }

  appendPage(items: E[]) : Pagination<E>{
    return new Pagination<E>(
      this.selector,
      this.pageSize,
      [...this.items, ...items],
      items.length >= this.pageSize,
      false
    )
  }

  refresh(items: E[]) : Pagination<E>{
    return new Pagination<E>(
      this.selector,
      this.pageSize,
      [...items],
      items.length >= this.pageSize,
      false
    )
  }
}
