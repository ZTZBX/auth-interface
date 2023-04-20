# auth_interface for ZTZBX Framework

### **Requirements**
- [core-ztzbx](https://github.com/ZTZBX/core-ztzbx)

**To preview the ui just press on this link: https://ztzbx.github.io/auth-interface/static/**

To build it, run `build.cmd`. To run it, run the following commands to make a symbolic link in your server data directory:

```dos
cd /d [PATH TO THIS RESOURCE]
mklink /d X:\cfx-server-data\resources\[local]\auth-interface dist
```

Afterwards, you can use `ensure auth-interface` in your server.cfg or server console to start the resource.
