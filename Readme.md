# BMI Functional Programming Example

## Apology

My purpose here is to noodle around with a functional approach to solving a personal problem.

You see, I lost 100 pounds some years back, and one of the things that made me aware of was that I was obese. Once I owned this fact I could take steps to fix it. And quantitatively measure my progress toward non-obesity. And eventually non-overweight.

BMI is measured in metric units and my scale and yardstick are in Imperial units. So, the notion of units conversion combined with the steps of the actual BMI calculation are good candidates for function composition.

Most educational examples are contrived. So is this one.

## Things broken

Authentication via ssh works for MacOS, but not Windows. As a result you have to set the remote URL to use https instead:

```text
url = https://github.com/StevePoling/bmi.git <--- Windoze
url = git@github.com:StevePoling/bmi.git     <--- civilization
```

Windoze works with GCM which is not as cross-platform as one might like. So they rewrote GCM-core in .NET. The trouble is that manager-core doesn't support ssh authentication. You can switch between credential.managers using git config.

Easiest way for me to change the remote url was just to edit .git/config. There's probably git command to switch it around I haven't gotten around to learning.

## Raspberry PI

Dotnet does not have an installer targeted for Raspberry PI OS. So, we do it like this:

```zsh
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel Current
ls ~/.dotnet
emacs ~/.zshrc
source ~/.zshrc
dotnet --version
```

Note that the install script puts dotnet into ~/.dotnet. Thus I have
to edit .zshrc to add it to the path before I can run dotnet.

Something similar can be said about Ubuntu. Sure, there's a 6.0
package you can get via apt-get. But that dotnet installer works for
Ubuntu as well. However, if you've got an old-stale .NET 6.0 already
installed, you'll have to manually start sudo rm-ing all the paths
that come up when you do whereis dotnet.

And you'll want to make sure the github authentication stuff is done.

```zsh
ssh-keygen -t ed25519 -C "user@computer" -f key-pair
cat key-pair.pub
emacs ~/.zshrc
```

Generate an ssh key-pair
Give its public key to github.com
Add the private key to ssh-agent.

## Things unfinished

### F# Implementation & Tests

But it let me get some exercise in the approach. And since I wanted to get better at xUnit, there's that, too.

You'll note that I didn't bother to test the F# equivalents. Uh, because I haven't written the F# solution yet...

### Multiple Platforms

At the moment .NET Core (or whatever .NET 7.0.0 calls itself) is running on MacOS, Linux, and another operating system made by the people who abandoned Xenix back in the '80s. So, after I check this project into Github I hope to copy it to my other computers and get it running there.

I wonder how one does a project that runs on both WSL and its host OS...

So much to learn.
