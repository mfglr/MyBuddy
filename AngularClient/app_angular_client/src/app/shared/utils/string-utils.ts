export function isNullOrWhiteSpace(value?: string): boolean {
  return !value || value.trim().length === 0;
}
