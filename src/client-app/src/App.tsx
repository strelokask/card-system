import { AuthProvider } from "./features/auth/AuthProvider";
import { RenderRoutes } from "./features/routes/RenderRoutes";

function App() {
  return (
    <AuthProvider>
      <RenderRoutes />
    </AuthProvider>
  );
}

export default App;
