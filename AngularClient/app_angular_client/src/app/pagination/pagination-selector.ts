import { PaginatinKey } from "./pagination-key";

export type PaginationSelector<T> = (item?: T) => Array<PaginatinKey<any>>;
