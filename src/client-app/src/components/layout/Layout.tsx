import { AppBar, Box, Button, Toolbar } from "@mui/material";
import { Outlet, useNavigate } from "react-router-dom";
import { AuthStatus } from "../../features/auth";

export function Layout() {
  const navItems = ["products", "settings"];

  const navigate = useNavigate();

  const toHomePage = () => navigate("/");
  //   <List>
  //   {navItems.map((item) => (
  //     <ListItem key={item}>
  //       {/* <Link to={item}>{item}</Link> */}
  //       <ListItemButton sx={{ textAlign: "center" }}>
  //         <ListItemText primary={item} />
  //       </ListItemButton>
  //     </ListItem>
  //   ))}
  // </List>
  return (
    <>
      <AppBar position="static">
        <Toolbar>
          <Button color="inherit" onClick={toHomePage}>
            Home
          </Button>
          <Box sx={{ flexGrow: 1 }}></Box>
          <AuthStatus />
        </Toolbar>
      </AppBar>
      <div id="root-content">
        <Outlet />
      </div>
    </>
  );
}
