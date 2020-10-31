<h2 align="center"> BolichePontos </h2>

<p align="center">
This repo should auxiliate on the counting of score in bowling. It uses a .NET Core ClassLib for the logic and xUnit for Unit Testing.
</p>

<p align="center">
  <a href="https://github.com/WesleyYS">
    <img alt="Made by Wesley Yago" src="https://img.shields.io/badge/made%20by-Wesley%20Yago-orange">
  </a>

  <img alt="Last Commit" src="https://img.shields.io/github/last-commit/WesleyYS/bolichePontos">

  <img alt="Contributors" src="https://img.shields.io/github/contributors/WesleyYS/bolichePontos">

  <img alt="License" src="https://img.shields.io/badge/license-MIT-orange">

  <a href="https://www.linkedin.com/in/wesley-yago-da-silva/">
    <img alt="Check out my LinkedIn!" src="https://img.shields.io/badge/-LinkedIn-black.svg?logo=linkedin&color=666">
  </a>
</p>

---

## Table of Contents

<ul>
  <li><a href="#-how-it-works">How it works</a></li>
  <li><a href="#-getting-started">Getting Started</a></li>
  <li><a href="#-features">Features</a></li>
  <li><a href="#-support">Support</a></li>
  <li><a href="#-license">License</a></li>
</ul>

---

## 🎳 How it works

### Rules

The bowling score system works with the following rules:
- the more pins knocked down with the least number of attempts (throws), the bigger the score
- each game has always 10 frames
- when the player knocks down 10 pins in a single throw, it's a strike
- when the player knocks down 10 total pins in different throws but in the same frame, it's a spare
- at each of the first 9 frames the player has 10 pins to knock down and:
  - only 1 throw if the first ball hits a strike, or
  - 2 throws if it doesn't
- at the frame 10 the player has 10 pins to knock down (that are restored after each strike/spare) and:
  - only 2 throws if none of the balls hit a strike or a spare, or
  - 3 throws if at least one of them do
- each pin knocked down is worth a point, but:
  - every strike multiplies the score of the next 2 throws on the next frame, and
  - every spare multiplies the score of the next throw on the next frame

### Situations

Expressions used in this section:

- normal throw: a ball thrown that hasn't scored a strike nor a spare.
- special throw: a ball that has scored either a strike or a spare.

A normal match with no special throws should last 20 throws.

An 'extended match' would be one where a special throw of any kind is reached at the 10th frame, resulting in an extra throw.

The least amount of score is 0 (all misses) and the highest is 300 (perfect match with 12 strikes).

The least amount of throws is 11 (9 strikes followed by 2 throws at the 10th frame that are non-special) and the highest is 21 (18 normal throws followed by a strike or spare at the 10th frame).

Two strikes in sequence should multiply the score of the next throw by 3.

### Test Cases

- [X] Should score 0 for gutter game (all losses).
- [X] Should score 20 for simple game (1 pin at every throw).
- [X] Should score 16 for a spare followed by a 3 ball ([4 + 6] + [3])
- [X] Should score 24 for a strike followed by a 3-point and a 4-point ball ([10] + [3 + 4])
- [X] Should score 23 for two sequential spares ([4 + 6] + [3 + 7])
- [X] Should score 300 for a perfect game (12 strikes)
- [X] Should score 30 for a strike followed by a spare ([10] + [5 + 5])
- [X] Should score 270 for 9 strikes followed by 5-point balls thrown 3 times at the 10th frame ([9 * 10] + [5 + 5 + 5])


---

## 🚀 Getting Started

### Prerequisites

- [.NET Core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

### Setup

Instructions to use:
- download or clone the repo
- run a Shell prompt inside the project's main folder (bolichePontos)
- enter the following command and press Enter:

```
dotnet test
```

- voilá!

---

## 📋 Features

Via the command prompt the program should be capable to:
- [X] Calculate the amount of score for games with no strikes or spares.
- [X] Calculate the effect of strikes and spares on the score.
- [X] Execute Unit Testing through xUnit and test the test cases described on this document.

The main idiom used is `[🇧🇷] Brazilian Portuguese`, my mother tongue.

### Documentation

This project uses the following Commit Guidelines:

- build: Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
- ci: Changes to our CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs)
- docs: Documentation only changes
- feat: A new feature
- fix: A bug fix
- perf: A code change that improves performance
- refactor: A code change that neither fixes a bug nor adds a feature
- style: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- test: Adding missing tests or correcting existing tests

---

## 📌 Support

Contact and support me through the following social medias:

- itch.io at [HypThaNyx](https://hypthanyx.itch.io/)
- Twitter at [@hypthanyx](https://twitter.com/hypthanyx)
- Instagram at [@hypthanyx](https://www.instagram.com/hypthanyx/)
- Linkedin at [Wesley Yago](https://www.linkedin.com/in/wesley-yago-da-silva/)
- Youtube at [HypThaNyx](https://www.youtube.com/channel/UC_x5u0TqJWN4O3GMwZRWkrg)

---

## 📝 License

<img alt="License" src="https://img.shields.io/badge/license-MIT-%2304D361">

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

🧰 Being developed by Wesley Yago!
