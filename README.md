# Reactive Disposal Samples

A few samples to show how to implement and use [ReactiveDisposal](https://github.com/InitialPrefabs/ReactiveDisposal).

Main documentation can be found on that project's [README](https://github.com/InitialPrefabs/ReactiveDisposal) and 
[wiki](https://github.com/InitialPrefabs/ReactiveDisposal/wiki) instead.

## How to initialize the repository?

This repository uses submodules so please follow the instruction below. The minimum version of Unity that has been
verified to work is `2019.2.x+`.

```
$ git clone https://github.com/InitialPrefabs/ReactiveDisposalSamples.git
$ cd ReactiveDisposalSamples
$ git submodule init && git submodule update
```

## How does this sample work?

In `SampleScene` there exists a single `SpriteRenderer` which will be converted into its entity based format. Do note
that the `SpriteRenderer` will be injected, not converted and destroyed.

To dispose the `SpriteRendererBlob` press the space bar and the entity and its component will be disposed of, thus
releasing the memory associated with it.

When destroyed, the `SpriteRenderer` itself won't be destroyed, this allows you to repool this `SpriteRenderer` or
destroy it manually yourself.
