import { PaginatinKey } from "./pagination-key";

export type PaginationSelector<E> = (entity: E) => Array<PaginatinKey<any>>;
