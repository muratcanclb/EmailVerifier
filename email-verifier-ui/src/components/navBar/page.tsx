import Link from "next/link";
import React from "react";
import { Button, Box, Grid } from "@mui/material";
import navBarStyles from "@/app/styles/navbar.module.css";
import SearchIcon from "@mui/icons-material/Search";
import { styled, alpha } from "@mui/material/styles";
import InputBase from "@mui/material/InputBase";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import MenuIcon from "@mui/icons-material/Menu";
import Avatar from "@mui/material/Avatar";
import Tooltip from '@mui/material/Tooltip';

function NavBarComponent() {
  return (
    <div>
      <Box sx={{ flexGrow: 1 }} className={navBarStyles.panel}>
        <AppBar position="static" className={navBarStyles.panel}>
          <Toolbar>
          
            <Grid container spacing={2}>
              <Grid item xs={10} className={navBarStyles.container}>
                <Box component="section" sx={{ p: 2, border: "1px grey" }}>
                  <img
                    style={{
                      width: "30%",
                      height: "auto",
                      border: "none",
                      cursor: "pointer",
                    }}
                    src="/images/logo.webp"
                  />
                </Box>

                <Box component="section" sx={{ p: 4, border: "1px grey" }}>
                  <Button
                    className={navBarStyles.navbarbutton}
                    color="secondary"
                  >
                    Anasayfa
                  </Button>
                  <Button
                    className={navBarStyles.navbarbutton}
                    color="secondary"
                  >
                    İletişim
                  </Button>
                  <Button
                    className={navBarStyles.navbarbutton}
                    color="secondary"
                  >
                    Hakkımızda
                  </Button>
                </Box>
              </Grid>
              <Grid item xs={2} className={navBarStyles.container}>
                <Box sx={{ flexGrow: 0 }}>
                  <Tooltip title="Open settings" >
                    <IconButton sx={{ p: 0 }}>
                      <Avatar
                        alt="Remy Sharp"
                        src="/static/images/avatar/3.jpg"
                      />
                    </IconButton>
                  </Tooltip>
                </Box>
              </Grid>
            </Grid>
          </Toolbar>
        </AppBar>
      </Box>
    </div>
  );
}

export default NavBarComponent;
