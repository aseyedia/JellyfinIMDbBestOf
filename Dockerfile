# Use the official Jellyfin image as the base
FROM jellyfin/jellyfin:latest

# Install dependencies required for .NET SDK
RUN apt-get update && apt-get install -y \
    wget \
    curl \
    unzip \
    libicu-dev \
    git \
    && rm -rf /var/lib/apt/lists/*

# Install .NET SDK
RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh \
    && chmod +x dotnet-install.sh \
    && ./dotnet-install.sh --channel 9.0 --install-dir /usr/share/dotnet \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Verify installation
RUN dotnet --version

# Set the working directory
WORKDIR /config/plugins/JellyfinIMDbBestOf
