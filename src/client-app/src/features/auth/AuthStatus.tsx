import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { useAuth } from "./AuthProvider";

export function AuthStatus() {
  const auth = useAuth();
  const navigate = useNavigate();

  const toLoginPage = () => navigate("/login");

  if (!auth.user) {
    return (
      <Button color="inherit" onClick={toLoginPage}>
        Login
      </Button>
    );
  }

  return (
    <p>
      Welcome {auth.user}!{" "}
      <button
        onClick={() => {
          auth.signout(() => navigate("/"));
        }}
      >
        Sign out
      </button>
    </p>
  );
}
