# 윈도우즈 기반의 파일 완전삭제 프로그램
#### 미국방성 기밀자료삭제기본지침(DoD5220 22-M)에 따른, 직관적인 인터페이스를 제공하는 파일 완전삭제 소프트웨어

## Author: Tackhyun Jung

## Status: 완료

## 개발일자 : 2015/01

### 핵심목표
1) 메타데이터와 데이터 영역을 구분하여 통제할 수 있는 기능 구현 (완료)
2) 데이터 영역을 0 혹은 난수로 여러번 효과적으로 덮어쓰는 기능 구현 (완료)
3) 직관적인 인터페이스 구현 (완료)

---

### 사용된 기술
* 파일완전삭제(File Wipe)

---

### Requirement
* C# (.NET FRAMEWORK 4.6.1)
* System.Security.Cryptography;
* System.Text.RegularExpressions;

---

### Usage

```
> Build Project
> Run Project
```

---
