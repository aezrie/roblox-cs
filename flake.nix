{
  description = "roblox-cs C# development environment";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = nixpkgs.legacyPackages.${system};
      in
      {
        devShells.default = pkgs.mkShell {
          name = "roblox-cs-env";

          buildInputs = with pkgs; [
            # .NET SDK
            dotnet-sdk_10

            # Useful tools
            git
            vim
            curl
          ];

          shellHook = ''
            echo "roblox-cs development environment loaded"
            dotnet --version
          '';
        };
      }
    );
}
