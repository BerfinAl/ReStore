import Catalog from "../../features/catalog/Catalog";
import { CssBaseline, Container, createTheme } from "@mui/material";
import Header from "./Header";
import { ThemeProvider } from "@emotion/react";
import { useState } from "react";
import { Outlet } from "react-router-dom";

function App() {
  const [darkMode, setDatkMode] = useState(false);

  const paletteType = darkMode ? "dark" : "light";

  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: { default: paletteType === "light" ? "#eaeaea" : "#121212"},
    },
  });

  function handleThemeChange() {
    return setDatkMode((prev) => !prev);
  }

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Header handleThemeChange={handleThemeChange} darkMode={darkMode} />
      <Container>
        <Outlet />
      </Container>
    </ThemeProvider>
  );
}

export default App;
