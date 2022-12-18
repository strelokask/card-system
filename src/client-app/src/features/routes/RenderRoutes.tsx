import { Route, Routes } from "react-router-dom";
import { HomePage } from "../../components/home/HomePage";
import { Layout } from "../../components/layout/Layout";
import { LoginPage } from "../../components/login/LoginPage";
import { RequireAuth } from "../auth";
import { RenderRoute } from "./RenderRoute";

// const HomePage = lazy(() => import("../../components/home/HomePage"));

export function RenderRoutes() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route
          path="/"
          element={
            <RenderRoute>
              <HomePage />
            </RenderRoute>
          }
        />
        <Route path="/login" element={<LoginPage />} />
        <Route
          path="/protected"
          element={
            <RequireAuth>
              <div>protected</div>
            </RequireAuth>
          }
        />
      </Route>
    </Routes>
  );
}
