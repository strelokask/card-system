import { FC, PropsWithChildren, Suspense } from "react";
import { ErrorBoundary } from "./ErrorBoundary";

export const RenderRoute: FC<PropsWithChildren> = ({ children }) => {
  return (
    <ErrorBoundary>
      <Suspense fallback={<h1>Loading...</h1>}>{children}</Suspense>
    </ErrorBoundary>
  );
};
